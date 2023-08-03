import axios from "axios";
import Cookies from "universal-cookie";
import { useNavigate, Link } from "react-router-dom";
import { LoginAction, LoginActionType } from "../../reducers/LoginReducer/LoginActions";
import { LoginState } from "../../reducers/LoginReducer/LoginState";
import "./loginBox.css";

interface LoginBoxProps {
  state: LoginState,
  dispatch: React.Dispatch<LoginAction>
}

export default ({
  state,
  dispatch
}: LoginBoxProps) => {
  const navigate = useNavigate();
  return (
    <div className="org-loginbox">
      <h2>Sign in</h2>
      <div className="form">
        <input 
          type="text"
          onChange={ (e) => dispatch({
            type: LoginActionType.UPDATE_LOGIN_FORM,
            username: e.currentTarget.value,
            password: state.password
          }) } />
        <input 
          type="password"
          onChange={ (e) => dispatch({
            type: LoginActionType.UPDATE_LOGIN_FORM,
            username: state.username,
            password: e.currentTarget.value
          }) } />
        <button 
          children="Login"
          onClick={ () => {
            dispatch({ type: LoginActionType.LOGIN_IN_PROGRESS });
            axios.post('http://localhost:3500/Login', {
              UserName: state.username,
              Password: state.password
            })
              .then(response => {
                dispatch({ type: LoginActionType.LOGIN_SUCCESS });
                new Cookies().set('TOKEN', response.data);
                navigate('/order');
              })
              .catch(err => dispatch({ 
                type: LoginActionType.LOGIN_ERROR 
              }))
          }} />
      </div>
      <Link to="/register">Don't have an account? Sign Up</Link>
    </div>
  );
}