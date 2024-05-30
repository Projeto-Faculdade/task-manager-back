package com.DesignPatterns.ApiDP.controller.request

import jakarta.persistence.Column

data class StudentyRequest (

        var name: String,

        var email: String,

        @Column(name = "preferred_language")
        var preferredLanguage: String


)