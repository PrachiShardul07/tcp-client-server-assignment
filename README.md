# TCP Client-Server Assignment

Hi!  
This project is a simple implementation of a TCP-based client-server system built using C# and .NET 8.

The goal of this assignment was to understand how real-time communication works between a client and a server using sockets, along with handling multiple clients and basic encryption.

##  What this project does

A client sends a message like: `SetA-Two`
The message is encrypted before being sent
The server receives and decrypts it
Based on predefined data, the server decides how many times to respond
It then sends the **current timestamp multiple times** (with a 1-second delay)
The client decrypts and displays the response

##  Example

Input:

SetA-Two

Output:

Server: 09-04-2026 18:17:01
Server: 09-04-2026 18:17:02

---

## Tech Used

- C#
- .NET 8
- TCP Sockets
- Multithreading
- Base64 Encoding (for encryption)

---

## Project Structure


TcpAssignment/
├── Server/
├── Client/
├── docs/
└── README.md


---

##  How to run the project

### 1. Start the server

cd Server
dotnet run


### 2. Start the client (in a new terminal)

cd Client
dotnet run


Then enter input like:

SetA-Two


---

##  Edge Case Handling

If invalid input is given:

SetX-Test

Output:

Server: EMPTY

---

##  What I learned

While working on this assignment, I got hands-on experience with:

- How TCP socket communication actually works
- Handling multiple clients using threads
- Sending and receiving real-time data
- Structuring backend logic for dynamic responses
- Debugging connection issues (like port errors, server not running, etc.)

---

##  What can be improved

If I had more time, I would enhance this project by:

- Using **AES encryption** instead of Base64
- Implementing **async/await** instead of threads
- Adding proper **logging**
- Making the dataset configurable (JSON/Database)
- Building a simple UI on top of it

---

##  About Me

I’m **Prachi Shardul**, a Full Stack Developer with experience in **.NET, Angular, and MERN stack**.  
I enjoy building real-world applications and continuously learning backend systems and architecture.

---

##  Final Note

This was a really interesting assignment that helped me understand networking concepts in a practical way. Looking forward to feedback!