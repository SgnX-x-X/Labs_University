import transport.*;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[2];
        transports[0] = new Car("Машина", 6);
        transports[1] = new Motobike("Мотоцикл", 5);

        for (int i = 0; i < transports.length; i++) {
            Transport transport = transports[i];
            try {
                transport.addModel("САМАЯ НОВАЯ МОДЕЛЬ", 9999999);
                // transport.addModel("САМАЯ НОВАЯ МОДЕЛЬ", -9999999);
                transport.setModelName("САМАЯ НОВАЯ МОДЕЛЬ", "ОЧЕНЬ СТАРАЯ МОДЕЛЬ");
                // transport.setModelName("МОДЕЛЬ ИЗ ДАЛЁКОГО БУДУЩЕГО", "СОВРЕМЕННАЯ МОДЕЛЬ");
                // transport.addModel("ОЧЕНЬ СТАРАЯ МОДЕЛЬ", 50000);
                transport.setModelCost(transport.getModelNames()[0], 100);
                transport.removeModel(transport.getModelNames()[1]);
                TransportStatic.show(transport);
                System.out.println("Средняя цена: " + TransportStatic.getAvgCost(transport));
            } catch (DuplicateModelNameException | NoSuchModelNameException | ModelPriceOutOfBoundsException e) {
                System.out.println("Ошибка: " + e.getMessage());
            }
        }
    }
}
