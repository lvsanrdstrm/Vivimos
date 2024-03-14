import React, { useState, useEffect, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import { Link } from "react-router-dom"
import '../assets/styles/nav.css'


function Nav() {

  const { activeUser, setActiveUser } = useContext(GlobalContext)

  const handleCreateAdClick = (e) => {
    if (!activeUser.loggedIn) {
      e.preventDefault()
      alert('Du är inte inloggad. Logga in eller skapa ett konto för att lägga in en annons')
    }
  }

  return <nav>
    

    <Link to="/">Hem</Link> &nbsp;
    <Link to="/Test">Test</Link> &nbsp;
    <Link to="/createAd" onClick={handleCreateAdClick}>Skapa annons</Link> &nbsp;
    { activeUser.loggedIn && (
      <>
      <Link to='/users/:id'>Min sida</Link> &nbsp;
      </>
    )}
  </nav>
}

export default Nav