import java.util.Random;

class MyFirstClass {
    public static void main(String[] args) {
        int i = 10;
        MySecondClass secondClass = new MySecondClass(i);
        int n = 500;
        secondClass.setElement(0, n);
        double avg = secondClass.getAvarage();
        System.out.println("среднее арифметическое: " + avg);
        secondClass.printArray();
    }
}

class MySecondClass {
    private int[] data;

    public MySecondClass(int size) {
        data = new int[size];
        Random random = new Random();
        for (int i = 0; i < size; i++) {
            data[i] = random.nextInt(1000);
        }
    }

    public int getElement(int index) {
        return data[index];
    }

    public void setElement(int index, int value) {
        data[index] = value;
    }

    public double getAvarage() {
        int sum = 0;
        for (int i = 0; i < data.length; i++) {
            sum += data[i];
        }
        return (double) sum / data.length;
    }

    public void printArray() {
        for (int i = 0; i < data.length; i++) {
            System.out.print(data[i] + " ");
        }
    }
}
