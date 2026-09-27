public class DuplicateModelNameException extends Exception {
    private final String modelName;

    public DuplicateModelNameException(String modelName) {
        super("Модель с названием " + modelName + " уже существует");
        this.modelName = modelName;
    }

    public String getModelName() {
        return modelName;
    }
}
