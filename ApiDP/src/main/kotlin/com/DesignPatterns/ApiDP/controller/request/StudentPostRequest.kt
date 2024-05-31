package com.DesignPatterns.ApiDP.controller.request


data class StudentPostRequest(

    var name: String = "",
    var email: String = "",
    var preferredLanguage: String = ""
)