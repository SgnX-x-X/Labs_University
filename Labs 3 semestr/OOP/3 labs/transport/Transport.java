package transport;

import java.io.Serializable;

public interface Transport extends Serializable {
    public abstract String getMark();

    public abstract void setMark(String mark);

    public abstract void setModelName(String oldName, String newName)
            throws NoSuchModelNameException, DuplicateModelNameException;

    public abstract String[] getModelNames();

    public abstract double getModelCost(String model) throws NoSuchModelNameException;

    public abstract void setModelCost(String model, double cost) throws NoSuchModelNameException;

    public abstract double[] getAllModelsCost();

    public abstract void addModel(String model, double cost) throws DuplicateModelNameException;

    public abstract void removeModel(String model) throws NoSuchModelNameException;

    public abstract int getModelsLength();
}
