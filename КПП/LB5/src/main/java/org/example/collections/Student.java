package org.example.collections;

import java.util.Objects;

public class Student implements Comparable<Student> {

    private int id;
    private String name;
    private int grade;

    public Student(int id, String name, int grade) {
        this.id = id;
        this.name = name;
        this.grade = grade;
    }

    // --- Геттери ---
    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public int getGrade() {
        return grade;
    }

    // --- Comparable: природне сортування за grade ---
    @Override
    public int compareTo(Student other) {
        return Integer.compare(this.grade, other.grade);
    }

    // --- equals() на основі id ---
    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof Student)) return false;
        Student student = (Student) o;
        return id == student.id;
    }

    // --- hashCode() на основі id ---
    @Override
    public int hashCode() {
        return Objects.hash(id);
    }

    // --- toString() для зручного виведення ---
    @Override
    public String toString() {
        return "Student{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", grade=" + grade +
                '}';
    }
}