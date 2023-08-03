import { createBrowserRouter, RouterProvider } from "react-router-dom";
import React from 'react'
import ReactDOM from 'react-dom/client'
import LoginPage from "./pages/LoginPage";
import RegisterPage from "./pages/RegisterPage";
import './index.css'
import OrderPage from "./pages/OrderPage";

const router = createBrowserRouter([
  { 
    path: '/', 
    element: <LoginPage />
  },
  { 
    path: '/login', 
    element: <LoginPage />
  },
  {
    path: '/register',
    element: <RegisterPage />
  },
  {
    path: '/order',
    element: <OrderPage />
  }
]);

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <RouterProvider router={router} />
  </React.StrictMode>,
)
