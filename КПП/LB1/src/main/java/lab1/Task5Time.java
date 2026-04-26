package lab1;

import java.util.Scanner;

public class Task5Time {
    public static void run() {
        Scanner scan = new Scanner(System.in);
        int totalSeconds;

        while (true) {
            System.out.print("Enter time in seconds: ");
            if (scan.hasNextInt()) {
                totalSeconds = scan.nextInt();
                if (totalSeconds >= 0) break;
            }
            System.out.println("Error: enter a non-negative integer.");
            scan.next();
        }

        int hours   = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;

        System.out.printf("Time = %02d:%02d:%02d%n", hours, minutes, seconds);
    }
}
