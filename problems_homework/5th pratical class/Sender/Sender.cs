using System;
using System.Messaging;

public class Sender{
    public static void Main(){
        MessageQueue messageQueue = MessageQueue.Create("SenderQueue");
        TransmitableObject transmitableObject = new TransmitableObject("Teste Object");
        messageQueue.Formatter = new BinaryMessageFormatter();
        messageQueue.Send(transmitableObject);
    }
}