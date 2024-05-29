package com.DesignPatterns.ApiDP.service

import com.DesignPatterns.ApiDP.controller.request.PostStudentyRequest
import com.DesignPatterns.ApiDP.model.Studenty
import com.DesignPatterns.ApiDP.repository.StudentyRepository
import jakarta.persistence.Id
import org.springframework.http.HttpStatus
import org.springframework.stereotype.Service
import org.springframework.web.server.ResponseStatusException
import java.lang.RuntimeException
import java.util.UUID

@Service
class StudentyService(
        val studentRepository: StudentyRepository
) {

    fun create(studenty: PostStudentyRequest) {
        studentRepository.save(Studenty(UUID.randomUUID(),studenty.name,studenty.email,studenty.preferredLanguage))

    }
    fun findAll(): List<Studenty> = studentRepository.findAll()

    fun findById(id: UUID): Studenty = studentRepository.findById(id).orElseThrow(){
        RuntimeException("Student not found")
    }

    fun update(studenty: Studenty){

        if(!studentRepository.existsById(studenty.id)){
            throw ResponseStatusException(HttpStatus.NOT_FOUND,"Student not found")
        }

        studentRepository.save(studenty)
    }

    fun delete(id: UUID){
        if(!studentRepository.existsById(id)){
            throw ResponseStatusException(HttpStatus.NOT_FOUND,"Student not found")
        }

        studentRepository.deleteById(id)
    }


}