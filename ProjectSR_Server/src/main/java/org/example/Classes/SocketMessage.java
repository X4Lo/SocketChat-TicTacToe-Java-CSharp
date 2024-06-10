package org.example.Classes;

import com.fasterxml.jackson.databind.ObjectMapper;

public class SocketMessage {
    private String senderId;
    private String senderUsername;
    private String type;
    private Object payload;
    private String receiverId;

    public SocketMessage() {}

    public SocketMessage(String senderId, String senderUsername, String type, Object payload, String receiverId) {
        this.senderId = senderId;
        this.senderUsername = senderUsername;
        this.type = type;
        this.payload = payload;
        this.receiverId = receiverId;
    }

    public String getSenderId() {
        return senderId;
    }

    public void setSenderId(String senderId) {
        this.senderId = senderId;
    }

    public String getSenderUsername() {
        return senderUsername;
    }

    public void setSenderUsername(String senderUsername) {
        this.senderUsername = senderUsername;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Object getPayload() {
        return payload;
    }

    public void setPayload(Object payload) {
        this.payload = payload;
    }

    public String getReceiverId() {
        return receiverId;
    }

    public void setReceiverId(String receiverId) {
        this.receiverId = receiverId;
    }
}