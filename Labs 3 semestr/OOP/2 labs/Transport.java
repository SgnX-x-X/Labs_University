public interface Transport {
    public abstract String getMark();

    public abstract void setMark(String mark);

    public abstract void setModelName(String oldName, String newName)
            throws NoSuchModelNameException, DuplicateModelNameException;

    public abstract String[] getAllModelsName();

    public abstract double getModelCost(String model);

    public abstract void setModelCost(String model, double cost);

    public abstract double[] getAllModelsCost();

    public abstract void addModel(String model, double cost);

    public abstract void removeModel(String model);

    public abstract int getModelsLength();
}
