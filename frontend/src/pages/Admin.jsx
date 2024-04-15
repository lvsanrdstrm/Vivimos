import React, { useState, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import { useNavigate } from "react-router-dom"



function Adminpage() {

  const { activeUser, setActiveUser } = useContext(GlobalContext)
  const {ads, setAds} = useContext(GlobalContext)
  const [userData, setUserData] = useState([])
  const [adData, setAdData] = useState([])
}