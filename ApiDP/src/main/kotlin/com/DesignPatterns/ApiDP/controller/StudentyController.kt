package com.DesignPatterns.ApiDP.controller

import com.DesignPatterns.ApiDP.controller.request.PostStudentyRequest
import com.DesignPatterns.ApiDP.service.StudentyService
import org.springframework.http.HttpStatus
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.ResponseStatus
import org.springframework.web.bind.annotation.RestController

@RestController
@RequestMapping("/students")
class StudentyController (
        val studentyService: StudentyService
){
    @GetMapping
    fun Mostrar(): String{
        return "Felipe bobão"
    }
    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    fun create(@RequestBody studenty: PostStudentyRequest){
        studentyService.create(studenty)

    }

}