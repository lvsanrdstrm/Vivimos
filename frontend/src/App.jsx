import Router from "./components/Router.jsx"
import { GlobalProvider } from './GlobalContext'
import './App.css'

function App() {

  return (
    <GlobalProvider>
      <Router />
    </GlobalProvider>
  )
}

export default App
