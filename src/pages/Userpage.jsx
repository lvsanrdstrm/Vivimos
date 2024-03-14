import React, { useContext, useEffect, useState } from 'react'
import { GlobalContext } from "../GlobalContext"
import { useParams, useLocation, useNavigate } from 'react-router-dom'


function Userpage() {
  
  const { activeUser, setActiveUser } = useContext(GlobalContext)
  let { id } = useParams()
  const [ userData, setUserData] = useState([])
  const [ adData, setAdData] = useState([])

  /* const location = useLocation()
  const navigate = useNavigate()
  if (!location.pathname.includes(`users/${activeUser.id}`) && activeUser) {
    
    navigate(`/users/${activeUser.id}`)
  } */

  useEffect(() => {
    const fetchUserData = async () => {
      try {
        const response = await fetch(`/api/users/${id}`)
        console.log(response)
        if (!response.ok) {
          console.error('Error fetching user data:', response.statusText)
          setUserData([])
          return
        }
        const data = await response.json()
        console.log(data)
        setUserData(data)
      } catch (error) {
        console.error('Error fetching user data:', error)
        setUserData([])
      }
    };
    if (id) {
      console.log(id)
    fetchUserData()
    }
  }, [id])

  if (!userData) {
    return <div>Laddar...</div>
  }

  useEffect(() => {
    if (userData) {
      console.log(userData)
      fetchAd()
    }
  }, [userData])

 

const fetchAd = async () => {
  console.log('fetching ad')
  const id = userData.id
  console.log(id)
    try {
      const response = await fetch(`/api/ads/?userId=${id}`)
      console.log(response)
      if (!response.ok) {
        console.error('Error fetching user data:', response.statusText)
        setAdData([])
        return
      }
      const data = await response.json()
      console.log(data)
      setAdData(data)
    } catch (error) {
      console.error('Error fetching user data:', error)
      setAdData([])
    }
}

if (!userData) {
  return <div>Laddar...</div>
}





  return (
    <>
     { !activeUser.loggedIn ? (
      <div className='userInfo-notLoggedIn'>
        <h2>Användare: {userData.username}</h2>
        <div className='userAuction'>
          <h2>Aktuell auktion</h2>
          {adData.length > 0 ? (
        <>
          <h3>{adData[0].rubrik}</h3>
          <p>{adData[0].län}</p>
        </>
      ) : (
        <p>Ingen aktuell auktion</p>
      )}

        </div>
      </div>
     ) : (
     
   
      <h2>Hej</h2>
    
    
  )}
  </>
  )

}


export default Userpage