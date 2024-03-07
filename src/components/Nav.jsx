import React, { useState, useEffect, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import { Link } from "react-router-dom"
import '../assets/styles/nav.css'


function Nav() {

  const { activeUser, setActiveUser } = useContext(GlobalContext)

  return <nav>
    

    <Link to="/">Hem</Link> &nbsp;
    <Link to="/Test">Test</Link> &nbsp;
    <Link to="/createOffer">Skapa annons</Link>
    { activeUser.loggedIn && (
      <>
      <Link to='/user/'>Min sida</Link> &nbsp;
      </>
    )}
  </nav>
}

export default Nav