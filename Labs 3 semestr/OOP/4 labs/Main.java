import transport.*;

public class Main {
    public static void main(String[] args) {
        Transport[] transports = new Transport[4];
        transports[0] = new Car("Машина", 6);
        transports[1] = new Motobike("Мотоцикл", 5);
        transports[2] = (Transport) ((Car) transports[0]).clone();
        transports[3] = (Transport) ((Motobike) transports[1]).clone();

        System.out
                .println("ссылки на автомобиль и клон: " + (transports[0] == transports[2] ? "одинаковые" : "разные"));
        System.out
                .println("ссылки на мотоцикл и клон: " + (transports[1] == transports[3] ? "одинаковые" : "разные"));
        System.out.println(
                "содержание автомобиля и клона: " + (transports[0].equals(transports[2]) ? "одинаковое" : "разное"));
        System.out.println("хэш оригинального автомобиля:" + transports[0].hashCode());
        System.out.println("хэш клона автомобиля:" + transports[2].hashCode());
        System.out.println(
                "содержание мотоцикла и клона: " + (transports[1].equals(transports[3]) ? "одинаковое" : "разное"));
        System.out.println("хэш оригинального мотоцикла:" + transports[1].hashCode());
        System.out.println("хэш клона мотоцикла:" + transports[3].hashCode());

        try {
            transports[2].setMark("Новый автомобиль");
            transports[3].setMark("Новый мотоцикл");
            transports[2].setModelCost(transports[2].getModelNames()[0], 123456.0);
            transports[3].addModel("Тестовая модель", 777777.0);
            transports[3].removeModel(transports[3].getModelNames()[0]);
        } catch (NoSuchModelNameException | ModelPriceOutOfBoundsException | DuplicateModelNameException e) {
            System.out.println("Ошибка: " + e.getMessage());
        }

        System.out.println("============================================");
        System.out.println("Весь транспорт:\n");
        for (Transport transport : transports) {
            System.out.println(transport);
            System.out.println("хэш: " + transport.hashCode() + "\n");
        }
    }
}
