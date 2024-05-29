package com.DesignPatterns.ApiDP.model

import jakarta.persistence.Column
import jakarta.persistence.Entity
import jakarta.persistence.GeneratedValue
import jakarta.persistence.GenerationType
import jakarta.persistence.Id
import java.util.UUID


@Entity(name = "studenty")
data class Studenty (
        @Id
        @GeneratedValue(strategy = GenerationType.UUID)
        var id: UUID,

        var name: String,

        var email: String,
        @Column(name = "preferred-language")
        var preferredLanguage: String

){
        constructor() :this(UUID.randomUUID(),"","","")
}


