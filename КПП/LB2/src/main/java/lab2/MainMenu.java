package lab2;

import java.util.Scanner;

public class MainMenu {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int choice;

        do {
            System.out.println("\n===== LAB 2 : Variant 18 =====");
            System.out.println("1 - Task 1 (y = sqrt(x), if)");
            System.out.println("2 - Task 2 (Check equality of two numbers)");
            System.out.println("3 - Task 3 (Season by month, switch)");
            System.out.println("4 - Task 4 (zero / non-zero, ternary)");
            System.out.println("5 - Task 5 (Multiplication table)");
            System.out.println("6 - Task 6 (Input until number > 100)");
            System.out.println("0 - Exit");
            System.out.print("Enter task number: ");

            while (!scanner.hasNextInt()) {
                System.out.println("Error: enter integer value.");
                scanner.next();
            }
            choice = scanner.nextInt();

            switch (choice) {
                case 1 -> Task1Sqrt.run();
                case 2 -> Task2EqualCheck.run();
                case 3 -> Task3Season.run();
                case 4 -> Task4ZeroCheck.run();
                case 5 -> Task5Multiplication.run();
                case 6 -> Task6InputUntilOver100.run();
                case 0 -> System.out.println("Program finished.");
                default -> System.out.println("Error: invalid menu option.");
            }
        } while (choice != 0);

        scanner.close();
    }
}