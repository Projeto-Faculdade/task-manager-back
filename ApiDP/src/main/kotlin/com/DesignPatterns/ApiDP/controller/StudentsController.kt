package com.DesignPatterns.ApiDP.controller

import com.DesignPatterns.ApiDP.controller.request.StudentPutRequest
import com.DesignPatterns.ApiDP.controller.request.StudentPostRequest
import org.springframework.http.HttpHeaders
import org.springframework.http.HttpStatus
import org.springframework.http.ResponseEntity
import org.springframework.http.ResponseEntity.*
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
import java.net.URI
import java.util.*

@RestController
@RequestMapping("/api/v1/students")
class StudentsController() {
    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    fun create(@RequestBody student: StudentPostRequest): BodyBuilder {

        return created(URI.create("students"))

    }

    @GetMapping
    fun findAll(@RequestHeader(HttpHeaders.ACCEPT_LANGUAGE) preferredLanguage: String): ResponseEntity<String> {
        return ok("OK")
    }

    @GetMapping("/{id}")
    fun findById(
        @PathVariable id: UUID,
        @RequestHeader(HttpHeaders.ACCEPT_LANGUAGE) preferredLanguage: String): ResponseEntity<String> {
        return ok("OK")
    }

    @PutMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    fun update(
        @PathVariable id: UUID, studentUpdate: StudentPutRequest
    ): BodyBuilder {

        studentUpdate.toEntity(id)
        return accepted()


    }


    @DeleteMapping("/{id}")
    @ResponseStatus(HttpStatus.NO_CONTENT)
    fun deleteById(@PathVariable id: UUID): HeadersBuilder<*> {
        return noContent()
    }

}