package org.example.collections;

import java.util.Comparator;

public class StudentIdComparator implements Comparator<Student> {

    @Override
    public int compare(Student a, Student b) {
        return Integer.compare(a.getId(), b.getId());
    }
}