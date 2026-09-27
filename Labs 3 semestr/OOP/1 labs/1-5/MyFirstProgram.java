import MyFirstPackage.MySecondClass;

class MyFirstClass {
    public static void main(String[] args) {
        int size = 10;
        MySecondClass secondClass = new MySecondClass(size);
        int newElements = 500;
        secondClass.setElement(0, newElements);
        double avg = secondClass.getAvarage();
        System.out.println("среднее арифметическое: " + avg);
        secondClass.printArray();
    }
}