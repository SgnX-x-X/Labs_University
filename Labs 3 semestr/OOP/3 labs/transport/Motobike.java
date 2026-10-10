package transport;

import java.io.Serializable;
import java.util.Random;

public class Motobike implements Transport {
    private class Model implements Serializable {
        String name = null;
        double cost = Double.NaN;
        Model prev = null;
        Model next = null;

        public Model() {
        }

        public Model(String name, double cost, Model prev, Model next) {
            this.name = name;
            this.cost = cost;
            this.prev = prev;
            this.next = next;
        }
    }

    private int size = 0;
    private Model head;
    private transient long lastModified;
    private String mark;

    {
        lastModified = System.currentTimeMillis();
        head = new Model();
        head.prev = head;
        head.next = head;
    }

    public Motobike(String mark, int modelsSize) {
        this.mark = mark;
        Random random = new Random();
        for (int i = 0; i < modelsSize; i++) {
            Model newModel = new Model(mark + (i + 1), random.nextDouble(1000, 100000), head.prev, head);
            head.prev.next = newModel;
            head.prev = newModel;
            size++;
        }
        lastModified = System.currentTimeMillis();
    }

    @Override
    public String getMark() {
        return mark;
    }

    @Override
    public void setMark(String new_mark) {
        mark = new_mark;
        lastModified = System.currentTimeMillis();
    }

    @Override
    public void setModelName(String oldName, String newName)
            throws DuplicateModelNameException, NoSuchModelNameException {
        Model target = null;
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(oldName)) {
                target = p;
            } else if (p.name.equals(newName)) {
                throw new DuplicateModelNameException(newName);
            }
            p = p.next;
        }
        if (target == null) {
            throw new NoSuchModelNameException(oldName);
        }
        target.name = newName;
        lastModified = System.currentTimeMillis();
    }

    @Override
    public String[] getModelNames() {
        String[] names = new String[size];
        Model p = head.next;
        int i = 0;
        while (p != head) {
            names[i] = p.name;
            i++;
            p = p.next;
        }
        return names;
    }

    @Override
    public double getModelCost(String name) throws NoSuchModelNameException {
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                return p.cost;
            }
            p = p.next;
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public void setModelCost(String name, double newCost) throws NoSuchModelNameException {
        if (newCost < 0) {
            throw new ModelPriceOutOfBoundsException(newCost);
        }
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                p.cost = newCost;
                lastModified = System.currentTimeMillis();
                return;
            }
            p = p.next;
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public double[] getAllModelsCost() {
        double[] costs = new double[size];
        Model p = head.next;
        int i = 0;
        while (p != head) {
            costs[i] = p.cost;
            i++;
            p = p.next;
        }
        return costs;
    }

    @Override
    public void addModel(String name, double cost) throws DuplicateModelNameException {
        if (cost < 0) {
            throw new ModelPriceOutOfBoundsException(cost);
        }
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                throw new DuplicateModelNameException(name);
            }
            p = p.next;
        }
        Model newModel = new Model(name, cost, head.prev, head);
        head.prev.next = newModel;
        head.prev = newModel;
        size++;
        lastModified = System.currentTimeMillis();
    }

    @Override
    public void removeModel(String name) throws NoSuchModelNameException {
        Model p = head.next;
        while (p != head) {
            if (p.name.equals(name)) {
                p.prev.next = p.next;
                p.next.prev = p.prev;
                size--;
                lastModified = System.currentTimeMillis();
                return;
            }
            p = p.next;
        }
        throw new NoSuchModelNameException(name);
    }

    @Override
    public int getModelsLength() {
        return size;
    }

    public long getLastModified() {
        return lastModified;
    }

}