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
}