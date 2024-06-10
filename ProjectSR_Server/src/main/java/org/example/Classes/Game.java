package org.example.Classes;

public class Game {
    private String id;
    private String type;

    private String player1_id;
    private String player1_username;
    private String player1_sign;

    private String player2_id;
    private String player2_username;
    private String player2_sign;

    private String turnId;
    private String winner;

    public Game() {
    }

    public Game(String id, String type, String player1_id, String player1_username, String player1_sign, String player2_id, String player2_username, String player2_sign, String turnId, String winner) {
        this.id = id;
        this.type = type;
        this.player1_id = player1_id;
        this.player1_username = player1_username;
        this.player1_sign = player1_sign;
        this.player2_id = player2_id;
        this.player2_username = player2_username;
        this.player2_sign = player2_sign;
        this.turnId = turnId;
        this.winner = winner;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public String getPlayer1_id() {
        return player1_id;
    }

    public void setPlayer1_id(String player1_id) {
        this.player1_id = player1_id;
    }

    public String getPlayer1_username() {
        return player1_username;
    }

    public void setPlayer1_username(String player1_username) {
        this.player1_username = player1_username;
    }

    public String getPlayer1_sign() {
        return player1_sign;
    }

    public void setPlayer1_sign(String player1_sign) {
        this.player1_sign = player1_sign;
    }

    public String getPlayer2_id() {
        return player2_id;
    }

    public void setPlayer2_id(String player2_id) {
        this.player2_id = player2_id;
    }

    public String getPlayer2_username() {
        return player2_username;
    }

    public void setPlayer2_username(String player2_username) {
        this.player2_username = player2_username;
    }

    public String getPlayer2_sign() {
        return player2_sign;
    }

    public void setPlayer2_sign(String player2_sign) {
        this.player2_sign = player2_sign;
    }

    public String getTurnId() {
        return turnId;
    }

    public void setTurnId(String turnId) {
        this.turnId = turnId;
    }

    public String getWinner() {
        return winner;
    }

    public void setWinner(String winner) {
        this.winner = winner;
    }
}
