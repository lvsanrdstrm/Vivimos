import { createContext, useState } from 'react'

const GlobalContext = createContext()

const GlobalProvider = ({ children }) => {
    const [ads, setAds] = useState([]);
    const [user, setUser] = useState([]);
    const [activeUser, setActiveUser] = useState({
        Username: '',
        Email: '',
        Id: '',
        Role: '',
        Ad: '',
        loggedIn: ''
    });
    const [modalOpen, setModalOpen] = useState(false);
    const [filteredAds, setFilteredAds] = useState([]);
    const [loginOpen, setLoginOpen] = useState(false);
    const [regOpen, setRegOpen] = useState(false);

    // Function to set activeUser data
    const setActiveUserData = (userData) => {
        setActiveUser(userData);
        console.log('Active user data updated:', userData);
    };

    return <GlobalContext.Provider value={{
        ads, setAds,
        user, setUser,
        activeUser, setActiveUserData,
        modalOpen, setModalOpen,
        loginOpen, setLoginOpen,
        regOpen, setRegOpen,
        filteredAds, setFilteredAds
    }}>
        {children}
    </GlobalContext.Provider>
}


export { GlobalProvider, GlobalContext }