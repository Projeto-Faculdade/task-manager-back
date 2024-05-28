package com.DesignPatterns.ApiDP.controller

import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.RestController

@RestController
class MostrarNome {

    @GetMapping("/nome")
    fun MostrarNome(): String{

        return  "Software Engineer"
    }
}