import transport.*;

import java.io.*;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[8];
        transports[0] = new Car("Четырёхколёсное", 6);
        transports[1] = new Motobike("Двухколёсное", 5);

        System.out.println("--- 1. Запись и чтение через байтовые потоки ---");
        try (OutputStream out = new FileOutputStream("car.transport")) {
            TransportStatic.outputTransport(transports[0], out);
            System.out.println("Автомобиль успешно записан в байтовый файл.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (OutputStream out = new FileOutputStream("bike.transport")) {
            TransportStatic.outputTransport(transports[1], out);
            System.out.println("Мотоцикл успешно записан в байтовый файл.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (InputStream in = new FileInputStream("car.transport")) {
            transports[2] = TransportStatic.inputTransport(in);
            transports[2].setMark("Прочитанная машина (байты)");
            System.out.println("Автомобиль успешно прочитан из байтового файла.");
        } catch (IOException | DuplicateModelNameException e) {
            e.printStackTrace();
        }

        try (InputStream in = new FileInputStream("bike.transport")) {
            transports[3] = TransportStatic.inputTransport(in);
            transports[3].setMark("Прочитанный мотоцикл (байты)");
            System.out.println("Мотоцикл успешно прочитан из байтового файла.\n");
        } catch (IOException | DuplicateModelNameException e) {
            e.printStackTrace();
        }

        System.out.println("--- 2. Запись и чтение через символьные потоки ---");
        try (FileWriter out = new FileWriter("car.txt")) {
            TransportStatic.writeTransport(transports[0], out);
            System.out.println("Автомобиль успешно записан через символьный поток.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (FileWriter out = new FileWriter("bike.txt")) {
            TransportStatic.writeTransport(transports[1], out);
            System.out.println("Мотоцикл успешно записан через символьный поток.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (FileReader in = new FileReader("car.txt")) {
            transports[4] = TransportStatic.readTransport(in);
            transports[4].setMark("Машина из текстового файла");
            System.out.println("Автомобиль успешно прочитан из символьного потока.");
        } catch (IOException | DuplicateModelNameException e) {
            e.printStackTrace();
        }

        try (FileReader in = new FileReader("bike.txt")) {
            transports[5] = TransportStatic.readTransport(in);
            transports[5].setMark("Мотоцикл из текстового файла");
            System.out.println("Мотоцикл успешно прочитан из символьного потока.\n");
        } catch (IOException | DuplicateModelNameException e) {
            e.printStackTrace();
        }

        System.out.println("--- 3. Сериализация и десериализация объектов ---");
        try (OutputStream fileOut = new FileOutputStream("car.serialized");
                ObjectOutputStream out = new ObjectOutputStream(fileOut)) {
            out.writeObject(transports[0]);
            System.out.println("Автомобиль успешно сериализован.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (OutputStream fileOut = new FileOutputStream("bike.serialized");
                ObjectOutputStream out = new ObjectOutputStream(fileOut)) {
            out.writeObject(transports[1]);
            System.out.println("Мотоцикл успешно сериализован.");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (InputStream fileIn = new FileInputStream("car.serialized");
                ObjectInputStream in = new ObjectInputStream(fileIn)) {
            transports[6] = (Transport) in.readObject();
            transports[6].setMark("Сериализованная машина");
            System.out.println("Автомобиль успешно десериализован.");
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }

        try (InputStream fileIn = new FileInputStream("bike.serialized");
                ObjectInputStream in = new ObjectInputStream(fileIn)) {
            transports[7] = (Transport) in.readObject();
            transports[7].setMark("Сериализованный мотоцикл");
            System.out.println("Мотоцикл успешно десериализован.\n");
        } catch (IOException | ClassNotFoundException e) {
            e.printStackTrace();
        }

        System.out.println("=================================================");
        System.out.println("   ВЫВОД ВСЕХ ТРАНСПОРТНЫХ СРЕДСТВ ИЗ МАССИВА   ");
        System.out.println("=================================================");
        for (int i = 0; i < transports.length; i++) {
            Transport t = transports[i];
            System.out.println("\n[Объект " + i + "]");
            System.out.println("Марка: " + t.getMark());
            System.out.println("Класс: " + t.getClass().getSimpleName());
            TransportStatic.show(t);
            System.out.printf("Средняя цена: %.2f\n", TransportStatic.getAvgCost(t));
        }

        System.out.println("\n=================================================");
        System.out.println("Ручной ввод транспорта через консоль (System.in):");
        System.out.println("Формат ввода:");
        System.out.println("  Строка 1: тип (Car или Motobike)");
        System.out.println("  Строка 2: марка");
        System.out.println("  Строка 3: количество моделей ");
        System.out.println("  Строки 4: чередуются название модели и её цена");
        System.out.println("=================================================");
        try {
            Transport transportFromReader = TransportStatic.readTransport(new InputStreamReader(System.in));
            OutputStreamWriter pw = new OutputStreamWriter(System.out);
            TransportStatic.writeTransport(transportFromReader, pw);
            pw.flush();
            System.out.println("=================================================");
            TransportStatic.show(transportFromReader);
            System.out.printf("Средняя цена: %.2f\n", TransportStatic.getAvgCost(transportFromReader));
        } catch (IOException | DuplicateModelNameException e) {
            e.printStackTrace();
        }
    }
}
