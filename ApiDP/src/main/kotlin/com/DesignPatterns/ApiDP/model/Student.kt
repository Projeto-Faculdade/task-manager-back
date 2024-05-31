package com.DesignPatterns.ApiDP.model

import jakarta.persistence.Column
import jakarta.persistence.Entity
import jakarta.persistence.GeneratedValue
import jakarta.persistence.GenerationType
import jakarta.persistence.Id
import java.util.UUID


@Entity
data class Student (
        @Id
        @GeneratedValue(strategy = GenerationType.UUID)
        var id: UUID,

        var name: String,

        var email: String,
        @Column(name = "preferred_language")
        var preferredLanguage: String

)

