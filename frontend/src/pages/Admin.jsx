import React, { useState, useContext } from 'react'
import { GlobalContext } from "../GlobalContext"
import { useNavigate } from "react-router-dom"



function Adminpage() {

  const { activeUser, setActiveUser } = useContext(GlobalContext)
  const { ads, setAds } = useContext(GlobalContext)
  const [userData, setUserData] = useState([])
  const [adData, setAdData] = useState([])
  const navigate = useNavigate()

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const response = await fetch('/api/admin')
        if (!response.ok) {
          console.error('Error fetching users:', response.statusText)
        }
      }
    }
  })
}