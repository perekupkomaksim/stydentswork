package lab3v18;

import lab3v18.tasks.Array1DTask;
import lab3v18.tasks.Array2DTask;
import lab3v18.tasks.JaggedArrayTask;
import lab3v18.tasks.ArrayObjectTask;

public class Main {
    public static void main(String[] args) {
        System.out.println("========================================");
        System.out.println("  LAB 3: Arrays | Variant 18");
        System.out.println("========================================");

        Array1DTask.run();
        Array2DTask.run();
        JaggedArrayTask.run();
        ArrayObjectTask.run();

        System.out.println("\n========================================");
        System.out.println("  Done.");
        System.out.println("========================================");
    }
}
