package lab3v18.io;

import java.util.Scanner;

public final class Input {
    private static final Scanner SC = new Scanner(System.in);

    private Input() {}

    public static int readInt(String prompt) {
        System.out.print(prompt);
        while (!SC.hasNextInt()) {
            System.out.println("Error: enter an integer.");
            SC.next();
            System.out.print(prompt);
        }
        return SC.nextInt();
    }
}
