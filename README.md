# SocketChat TicTacToe Java CSharp

This is a real-time multiplayer TicTacToe game application, facilitating interaction between players through a live chat feature. The server-side is implemented in Java, capable of handling multiple clients simultaneously, while the client-side interface utilizes Windows Forms in C#.

## Key Features

- **Real-Time Chat**: Engage in live conversations with other players.
- **Dynamic Player Connection**: Players can connect by choosing a username.
- **Game Invitations**: View online players, send game invitations, and start playing upon acceptance.
- **Scalable Server**: The Java server can manage numerous client connections concurrently.

## Communication

Communication between the server and clients is managed using the `SocketMessage` class, structured as follows:

```java
public class SocketMessage
{
    public string SenderId { get; set; }
    public string SenderUsername { get; set; }
    public string Type { get; set; }
    public object Payload { get; set; }
    public string ReceiverId { get; set; }
}
```

Messages are serialized into JSON strings for transmission and then deserialized back into `SocketMessage` objects upon receipt.

## Diagrams Sections

### User Connection Process
![User Connection Process](/images/1.png)


The process for connecting a client to the server in the application involves a series of steps to establish and confirm the client's identity:

1. **Client Socket Connection Established**: Once the client establishes a socket connection with the server:
    - The server generates a unique ID for the new client.
    - This ID is sent to the client encapsulated within a `SocketMessage` of type `"setId"`.
2. **Client Receives ID**:
    - Upon receiving the ID, the client sends back a `SocketMessage` of type `"setUsername"`.
    - This message includes the chosen username, allowing the client to identify itself to the server.
3. **Server Receives Username**:
    - When the server receives the username, it updates its list of connected users to include the new client.
    - It then broadcasts the updated list of all connected users to each user, ensuring everyone is aware of the new player's presence.
This sequence ensures that each client is properly registered and visible to other players, facilitating interaction and game invitations.
### System Structure
![System Structure](/images/2.png)


