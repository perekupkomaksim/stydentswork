package org.example.collections;

public class BadStudent extends Student {

    public BadStudent(int id, String name, int grade) {
        super(id, name, grade);
    }

    // Усі об'єкти потрапляють в один bucket
    @Override
    public int hashCode() {
        return 1;
    }
}