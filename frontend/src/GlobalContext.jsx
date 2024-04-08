import { createContext, useState } from 'react'

const GlobalContext = createContext()

function GlobalProvider({ children }) {
    const [ads, setAds] = useState([])
    const [user, setUser] = useState([])
    const [activeUser, setActiveUser] = useState({})
    const [modalOpen, setModalOpen] = useState(false)
    const [filteredAds, setFilteredAds] = useState([])

    const [ loginOpen, setLoginOpen ] = useState(false)
    const [ regOpen, setRegOpen ] = useState(false)

    return <GlobalContext.Provider value={{ 
      ads, setAds, 
      user, setUser, 
      activeUser, setActiveUser, 
      modalOpen, setModalOpen,
      loginOpen, setLoginOpen,
      regOpen, setRegOpen,
      filteredAds, setFilteredAds
       }}>
        {children}
    </GlobalContext.Provider>
}


export { GlobalProvider, GlobalContext }