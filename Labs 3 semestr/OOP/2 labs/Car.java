public class Car implements Transport {

    private String mark;
    private Model[] models;

    private class Model {
        public String name;
        public double cost;

        public Model(String name, double cost) {
            this.name = name;
            this.cost = cost;
        }
    }

    public String getMark() {
        return this.mark;
    }

    public void setMark(String mark) {
        this.mark = mark;
    }

    public void setModelName(String oldName, String newName)
            throws NoSuchModelNameException, DuplicateModelNameException {
        
    }

    

}