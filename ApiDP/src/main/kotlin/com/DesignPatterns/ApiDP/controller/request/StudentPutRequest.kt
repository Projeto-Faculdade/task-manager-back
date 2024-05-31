package com.DesignPatterns.ApiDP.controller.request

import com.DesignPatterns.ApiDP.model.Student
import java.util.*

data class StudentPutRequest(
    var name: String?,
    var email: String?,
    var preferredLanguage: String?


) {
    fun toEntity(id: UUID): Student {
        return Student(id, this.name!!, this.email!!,this.preferredLanguage!!)
    }
}
