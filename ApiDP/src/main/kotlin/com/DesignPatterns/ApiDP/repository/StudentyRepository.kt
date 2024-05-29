package com.DesignPatterns.ApiDP.repository

import com.DesignPatterns.ApiDP.model.Studenty
import org.springframework.data.jpa.repository.JpaRepository
import org.springframework.stereotype.Repository
import java.util.UUID

@Repository
interface StudentyRepository : JpaRepository<Studenty,UUID> {

}