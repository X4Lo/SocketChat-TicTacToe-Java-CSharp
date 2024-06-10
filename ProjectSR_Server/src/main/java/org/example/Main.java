package org.example;

import org.example.Classes.Client;
import org.example.Classes.Game;
import org.example.Classes.SocketMessage;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.*;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;

public class Main {
    private static final int PORT = 12345;
    private static ExecutorService threadPool = Executors.newCachedThreadPool();
    public static Map<String, Client> clients = new HashMap<>();
    public static Map<String, Game> games = new HashMap<>();

    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(PORT)) {
            System.out.println("Server is listening on port " + PORT);

            while (true) {
                Socket socket = serverSocket.accept();
                String clientId = UUID.randomUUID().toString();
                Client client = new Client(socket, clientId);
                clients.put(clientId, client);
                System.out.println("New client connected with ID: " + clientId);

                client.startCommunication();
            }
        } catch (Exception e) {
            System.out.println("Server exception: " + e.getMessage());
        }
    }

    public static void sendToUser(SocketMessage socketMessage) {
        clients.forEach((id, client) -> {
            if (Objects.equals(id, socketMessage.getReceiverId())) {
                try {
                    client.send(socketMessage);
                } catch (IOException e) {
                    throw new RuntimeException(e);
                }
            }
        });
    }

    public static void sendToAll(SocketMessage socketMessage, boolean includeSender) {
        clients.forEach((id, client) -> {
            try {
                if (id != socketMessage.getSenderId() || includeSender) {
                    client.send(socketMessage);
                }
            } catch (IOException e) {
                throw new RuntimeException(e);
            }
        });
    }

    public static Map<String, String> getClients() {
        Map<String, String> clientDetails = new HashMap<>();
        for (Map.Entry<String, Client> entry : clients.entrySet()) {
            String clientId = entry.getKey();
            String username = entry.getValue().getClientUsername();
            clientDetails.put(clientId, username);
        }
        return clientDetails;
    }

    public static void removeClient(String id) {
        clients.remove(id);

        SocketMessage sm = new SocketMessage();
        sm.setType("usersList");
        sm.setPayload(Main.getClients());

        Main.sendToAll(sm, false);
    }
}