package com.DesignPatterns.ApiDP.controller

import com.DesignPatterns.ApiDP.controller.request.PutStudentyRequest
import com.DesignPatterns.ApiDP.controller.request.StudentyRequest
import com.DesignPatterns.ApiDP.model.Studenty
import com.DesignPatterns.ApiDP.repository.StudentyRepository
import org.springframework.http.HttpStatus
import org.springframework.web.bind.annotation.DeleteMapping
import org.springframework.web.bind.annotation.GetMapping
import org.springframework.web.bind.annotation.PathVariable
import org.springframework.web.bind.annotation.PostMapping
import org.springframework.web.bind.annotation.PutMapping
import org.springframework.web.bind.annotation.RequestBody
import org.springframework.web.bind.annotation.RequestHeader
import org.springframework.web.bind.annotation.RequestMapping
import org.springframework.web.bind.annotation.ResponseStatus
import org.springframework.web.bind.annotation.RestController
import org.springframework.web.server.ResponseStatusException
import java.util.*

@RestController
@RequestMapping("/v1")
class StudentyController (
        val studentyRepository: StudentyRepository
){
    @PostMapping("/studenty")
    @ResponseStatus(HttpStatus.CREATED)
    fun create(
            @RequestBody studenty: StudentyRequest,
            @RequestHeader("preferedLanguage") preferedLanguage: String
            ){
        studentyRepository.save(Studenty(UUID.randomUUID(),studenty.name,studenty.email,studenty.preferredLanguage))
    }
    @GetMapping("/students")
    fun findAll(): List<Studenty>{
        return studentyRepository.findAll();
    }

    @GetMapping("/{id}")
    fun findById(@PathVariable id: UUID,@RequestBody studenty: StudentyRequest){
        studentyRepository.findById(id)
    }

    @PutMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    fun update(@PathVariable id: UUID,studentUpdate: PutStudentyRequest){


    }


    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    fun deleteById(@PathVariable id: UUID){
        studentyRepository.deleteById(id)
    }

}