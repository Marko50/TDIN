using System;
using System.Messaging;
public class Reader{
    public static void Main(){
        MessageQueue messageQueue = new MessageQueue(TransmitableObject.QUEUE_NAME);
        messageQueue.Formatter = new BinaryMessageFormatter();
        Message message = messageQueue.Receive();
        TransmitableObject transmitableObject = (TransmitableObject) message.Body;
        Console.WriteLine(transmitableObject.ToString());
    }
}