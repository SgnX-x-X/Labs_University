package transport;

import java.io.BufferedReader;
import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.Reader;
import java.io.Writer;
import java.nio.charset.StandardCharsets;

public class TransportStatic {

    public static void show(Transport transport) {
        String[] names = transport.getModelNames();
        double[] prices = transport.getAllModelsCost();

        for (int i = 0; i < names.length; i++) {
            System.out.println(names[i] + " : " + prices[i]);
        }
    }

    public static double getAvgCost(Transport transport) {
        if (transport == null) {
            throw new IllegalArgumentException("Транспортное средство не может быть null");
        }
        double[] prices = transport.getAllModelsCost();
        if (prices.length == 0) {
            throw new ArithmeticException("Отсутствуют модели, вычисление средней цены невозможно");
        }
        double sum = 0;
        for (double price : prices) {
            sum += price;
        }
        return sum / prices.length;
    }

    public static void outputTransport(Transport v, OutputStream out) throws IOException {
        DataOutputStream dos = new DataOutputStream(out);

        byte[] classBytes = v.getClass().getSimpleName().getBytes(StandardCharsets.UTF_8);
        dos.writeInt(classBytes.length);
        dos.write(classBytes);

        byte[] markBytes = v.getMark().getBytes(StandardCharsets.UTF_8);
        dos.writeInt(markBytes.length);
        dos.write(markBytes);

        int length = v.getModelsLength();
        dos.writeInt(length);

        String[] names = v.getModelNames();
        double[] prices = v.getAllModelsCost();

        for (int i = 0; i < length; i++) {
            byte[] nameBytes = names[i].getBytes(StandardCharsets.UTF_8);
            dos.writeInt(nameBytes.length);
            dos.write(nameBytes);
            dos.writeDouble(prices[i]);
        }
        dos.flush();
    }

    public static Transport inputTransport(InputStream in) throws IOException, DuplicateModelNameException {
        DataInputStream dis = new DataInputStream(in);

        int classLength = dis.readInt();
        byte[] classBytes = new byte[classLength];
        dis.readFully(classBytes);
        String type = new String(classBytes, StandardCharsets.UTF_8);

        int markLength = dis.readInt();
        byte[] markBytes = new byte[markLength];
        dis.readFully(markBytes);
        String mark = new String(markBytes, StandardCharsets.UTF_8);

        int length = dis.readInt();
        Transport transport;
        switch (type) {
            case "Motobike":
                transport = new Motobike(mark, 0);
                break;
            case "Car":
                transport = new Car(mark, 0);
                break;
            default:
                throw new IllegalArgumentException("Неизвестный тип транспортного средства: " + type);
        }

        for (int i = 0; i < length; i++) {
            int nameLength = dis.readInt();
            byte[] nameBytes = new byte[nameLength];
            dis.readFully(nameBytes);
            String name = new String(nameBytes, StandardCharsets.UTF_8);

            double price = dis.readDouble();
            transport.addModel(name, price);
        }
        return transport;
    }

    public static void writeTransport(Transport v, Writer out) {
        PrintWriter pw = new PrintWriter(out);
        pw.println(v.getClass().getSimpleName());
        pw.println(v.getMark());
        int length = v.getModelsLength();
        pw.println(length);
        String[] names = v.getModelNames();
        double[] prices = v.getAllModelsCost();
        for (int i = 0; i < length; i++) {
            pw.println(names[i]);
            pw.println(prices[i]);
        }
        pw.flush();
    }

    public static Transport readTransport(Reader in) throws IOException, DuplicateModelNameException {
        BufferedReader br = new BufferedReader(in);
        String type = br.readLine();
        String mark = br.readLine();
        int length = Integer.parseInt(br.readLine());

        Transport transport;
        switch (type) {
            case "Motobike":
                transport = new Motobike(mark, 0);
                break;
            case "Car":
                transport = new Car(mark, 0);
                break;
            default:
                throw new IllegalArgumentException("Неизвестный тип транспортного средства: " + type);
        }

        for (int i = 0; i < length; i++) {
            String name = br.readLine();
            double price = Double.parseDouble(br.readLine());
            transport.addModel(name, price);
        }
        return transport;
    }
}