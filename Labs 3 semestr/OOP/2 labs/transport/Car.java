package transport;

import java.util.Arrays;
import java.util.Random;

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

    public Car(String mark, int modelCount) {
        this.mark = mark;
        models = new Model[modelCount];
        Random random = new Random();
        for (int i = 0; i < modelCount; i++) {
            models[i] = new Model(mark + (i + 1), random.nextDouble(1000, 1000000));
        }
    }

    @Override
    public String getMark() {
        return mark;
    }

    @Override
    public void setMark(String mark) {
        this.mark = mark;
    }

    @Override
    public void setModelName(String oldName, String newName)
            throws NoSuchModelNameException, DuplicateModelNameException {
        Model targetModel = null;
        for (int i = 0; i < models.length; i++) {
            if (models[i].name.equals(oldName)) {
                targetModel = models[i];
            } else if (models[i].name.equals(newName)) {
                throw new DuplicateModelNameException(newName);
            }
        }
        if (targetModel == null) {
            throw new NoSuchModelNameException(oldName);
        } else {
            targetModel.name = newName;
        }
    }

    @Override
    public String[] getModelNames() {
        String[] modelNames = new String[models.length];
        for (int i = 0; i < models.length; i++) {
            modelNames[i] = models[i].name;
        }
        return modelNames;
    }

    @Override
    public double getModelCost(String model) throws NoSuchModelNameException {
        for (int i = 0; i < models.length; i++) {
            if (models[i].name.equals(model)) {
                return models[i].cost;
            }
        }
        throw new NoSuchModelNameException(model);
    }

    @Override
    public void setModelCost(String name, double newCost) throws NoSuchModelNameException {
        if (newCost < 0) {
            throw new ModelPriceOutOfBoundsException(newCost);
        }
        for (Model model : models) {
            if (model.name.equals(name)) {
                model.cost = newCost;
                return;
            }
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public double[] getAllModelsCost() {
        double[] costs = new double[models.length];
        for (int i = 0; i < models.length; i++) {
            costs[i] = models[i].cost;
        }
        return costs;
    }

    @Override
    public void addModel(String name, double cost) throws DuplicateModelNameException {
        if (cost < 0) {
            throw new ModelPriceOutOfBoundsException(cost);
        }
        for (int i = 0; i < models.length; i++) {
            if (models[i].name.equals(name)) {
                throw new DuplicateModelNameException(name);
            }
        }
        models = Arrays.copyOf(models, models.length + 1);
        models[models.length - 1] = new Model(name, cost);
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
        int targetIndex = -1;
        for (int i = 0; i < models.length; i++) {
            if (models[i].name.equals(name)) {
                targetIndex = i;
                break;
            }
        }
        if (targetIndex < 0) {
            throw new NoSuchModelNameException(name);
        }
        System.arraycopy(models, targetIndex + 1, models, targetIndex, models.length - targetIndex - 1);
        models = Arrays.copyOf(models, models.length - 1);
    }

    @Override
    public int getModelsLength() {
        return models.length;
    }
}