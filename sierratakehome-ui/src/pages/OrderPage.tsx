import { useEffect, useReducer } from "react";
import { useNavigate } from "react-router-dom";
import Cookies from "universal-cookie";
import OrderReducer from "../reducers/OrderReducer/OrderReducer";
import { OrderInitialState } from "../reducers/OrderReducer/OrderState";
import OrderTemplate from "../templates/OrderTemplate/OrderTemplate";
import { OrderActionType } from "../reducers/OrderReducer/OrderActions";
import axios from "axios";

export default () => {
  const [state, dispatch] = useReducer(OrderReducer, OrderInitialState);
  const token = new Cookies().get('TOKEN');
  const navigate = useNavigate();

  useEffect(() =>{
    if (token == null) {
      navigate('/login');
    }

    dispatch({ type: OrderActionType.LOAD_ORDERS_IN_PROGRESS });
    axios.get(
      'http://localhost:3500/Order', 
      { headers: {
          "Authorization": `Bearer ${token}`,
          "Content-Type": 'application/json'
        } })
      .then(response => {
        dispatch({ 
          type: OrderActionType.LOAD_ORDERS_SUCCESS,
          orders: response.data
        });
      })
      .catch(_ => dispatch({ 
        type: OrderActionType.LOAD_ORDERS_ERROR 
      }));
  }, []);
  

  return (
    <OrderTemplate
      state={ state }
      dispatch={ dispatch } />
  );
}