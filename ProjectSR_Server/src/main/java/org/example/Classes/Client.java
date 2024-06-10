package org.example.Classes;

import com.fasterxml.jackson.databind.ObjectMapper;
import org.example.Main;

import java.net.Socket;
import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.io.BufferedWriter;
import java.io.OutputStreamWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.UUID;

public class Client {
    private Socket socket;
    private String clientId;
    private String clientUsername;

    private BufferedReader reader;
    private BufferedWriter writer;
    private Thread sendThread;
    private Thread receiveThread;
    private ObjectMapper objectMapper = new ObjectMapper();  // json objet mapper

    public Client(Socket socket, String clientId) throws IOException {
        this.socket = socket;
        this.clientId = clientId;
        this.reader = new BufferedReader(new InputStreamReader(socket.getInputStream()));
        this.writer = new BufferedWriter(new OutputStreamWriter(socket.getOutputStream()));
    }

    public void startCommunication() throws IOException {
        startReceiving(); // start the recieving thread

        // sending the generated id to client
        SocketMessage sm = new SocketMessage();
        sm.setType("setId");
        sm.setPayload(clientId);
        this.send(sm);
    }

    private void startReceiving() {
        receiveThread = new Thread(() -> {
            try {
                String line;
                while ((line = reader.readLine()) != null) {
                    SocketMessage message = objectMapper.readValue(line, SocketMessage.class);
                    processMessage(message);
                }
            } catch (IOException e) {
                System.out.println("Error receiving data from client " + clientId + ": " + e.getMessage());
            } finally {
                cleanup();
            }
        });
        receiveThread.start();
    }

    public void processMessage(SocketMessage message) throws IOException {
        if (message.getType().equals("setUsername")) {
            this.clientUsername = message.getPayload().toString();
            System.out.println("Username: [" + this.clientUsername + "] set for client: " + this.clientId);

            SocketMessage sm = new SocketMessage();
            sm.setType("usersList");
            sm.setPayload(Main.getClients());

            Main.sendToAll(sm, true);
        }

        if (message.getType().equals("chat")) {
            Main.sendToAll(message, false);
        }

        if (message.getType().equals("gameInvite")) {
            System.out.println(message.getSenderUsername() + " invited [" + message.getReceiverId() + "] to a game of " + message.getPayload().toString());
            Main.sendToUser(message);
        }

        if (message.getType().equals("gameStart")) {
            if (message.getPayload().toString().equals("XO")) {
                XO game = new XO();
                game.setId(UUID.randomUUID().toString());
                game.setType("XO");

                game.setPlayer1_id(message.getSenderId());
                game.setPlayer1_username(message.getSenderUsername());
                game.setPlayer1_sign("X");

                game.setPlayer2_id(message.getReceiverId());
                game.setPlayer2_username(Main.clients.get(message.getReceiverId()).getClientUsername());
                game.setPlayer2_sign("O");

                game.setTurnId(message.getSenderId()); // maybe use random
                game.setWinner("");

                ArrayList<String> gameData = new ArrayList<>(Collections.nCopies(9, ""));
                game.setData(gameData);

                Main.games.put(game.getId(), game);

                SocketMessage sm = new SocketMessage();
                sm.setType("gameStart");
                sm.setReceiverId(game.getPlayer1_id());
                sm.setPayload(game);
                Main.sendToUser(sm);

                SocketMessage sm2 = new SocketMessage();
                sm2.setType("gameStart");
                sm2.setReceiverId(game.getPlayer2_id());
                sm2.setPayload(game);
                Main.sendToUser(sm2);
            }
        }

        if (message.getType().equals("gamePlay")) {
            XO game = (XO) Main.games.get(message.getPayload());

            // jouer le tour
            int index = Integer.parseInt(message.getReceiverId().toString());
            String senderSign;
            if (game.getPlayer1_id().equals(message.getSenderId())) {
                senderSign = game.getPlayer1_sign();
            } else {
                senderSign = game.getPlayer2_sign();
            }

            List<String> oldMatrice = game.getData();
            oldMatrice.set(index, senderSign);
            game.setData(oldMatrice);

            // passer le tour au deuxieme joueur
            if (game.getTurnId() == game.getPlayer1_id()) {
                game.setTurnId(game.getPlayer2_id());
            } else {
                game.setTurnId(game.getPlayer1_id());
            }

            // check if someone won
            boolean isFull = true;
            for (String cell : oldMatrice) {
                if (cell == null || cell.isEmpty()) {
                    isFull = false;
                    break;
                }
            }

            if (
                    (!oldMatrice.get(0).isEmpty() && oldMatrice.get(0).equals(oldMatrice.get(1)) && oldMatrice.get(1).equals(oldMatrice.get(2))) ||
                            (!oldMatrice.get(3).isEmpty() && oldMatrice.get(3).equals(oldMatrice.get(4)) && oldMatrice.get(4).equals(oldMatrice.get(5))) ||
                            (!oldMatrice.get(6).isEmpty() && oldMatrice.get(6).equals(oldMatrice.get(7)) && oldMatrice.get(7).equals(oldMatrice.get(8))) ||
                            (!oldMatrice.get(0).isEmpty() && oldMatrice.get(0).equals(oldMatrice.get(3)) && oldMatrice.get(3).equals(oldMatrice.get(6))) ||
                            (!oldMatrice.get(1).isEmpty() && oldMatrice.get(1).equals(oldMatrice.get(4)) && oldMatrice.get(4).equals(oldMatrice.get(7))) ||
                            (!oldMatrice.get(2).isEmpty() && oldMatrice.get(2).equals(oldMatrice.get(5)) && oldMatrice.get(5).equals(oldMatrice.get(8))) ||
                            (!oldMatrice.get(0).isEmpty() && oldMatrice.get(0).equals(oldMatrice.get(4)) && oldMatrice.get(4).equals(oldMatrice.get(8))) ||
                            (!oldMatrice.get(2).isEmpty() && oldMatrice.get(2).equals(oldMatrice.get(4)) && oldMatrice.get(4).equals(oldMatrice.get(6)))
            ) {
                game.setWinner(message.getSenderUsername());
            } else if (isFull) {
                game.setWinner("Draw");
            }

            SocketMessage sm = new SocketMessage();
            sm.setType("gameUpdate");
            sm.setReceiverId(game.getPlayer1_id());
            sm.setPayload(game);
            Main.sendToUser(sm);

            SocketMessage sm2 = new SocketMessage();
            sm2.setType("gameUpdate");
            sm2.setReceiverId(game.getPlayer2_id());
            sm2.setPayload(game);
            Main.sendToUser(sm2);

            if (game.getWinner() != "") {
                Main.games.remove(game.getId());
            }
        }

    }

    public void send(SocketMessage socketMessage) throws IOException {
        if(socket.isClosed()){
            cleanup();
            return;
        }
        String jsonMessage = objectMapper.writeValueAsString(socketMessage);
//        System.out.println("sending: " + jsonMessage);
        writer.write(jsonMessage);
        writer.newLine();
        writer.flush();
    }

    private void cleanup() {
        try {
            socket.close();
            reader.close();
            writer.close();
            Main.removeClient(this.clientId);
        } catch (IOException e) {
            System.out.println("Error closing resources for client " + clientId);
        }
    }

    public String getClientId() {
        return clientId;
    }

    public void setClientId(String clientId) {
        this.clientId = clientId;
    }

    public String getClientUsername() {
        return clientUsername;
    }

    public void setClientUsername(String clientUsername) {
        this.clientUsername = clientUsername;
    }
}
