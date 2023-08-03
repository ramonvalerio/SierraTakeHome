import axios from "axios";
import { useNavigate, Link } from "react-router-dom";
import { RegisterState } from "../../reducers/RegisterReducer/RegisterState";
import "./registerBox.css";
import { RegisterAction, RegisterActionType } from "../../reducers/RegisterReducer/RegisterActions";
import Cookies from "universal-cookie";

interface RegisterBoxProps {
  state: RegisterState,
  dispatch: React.Dispatch<RegisterAction>
}

export default ({
  state,
  dispatch
}: RegisterBoxProps) => {
  const navigate = useNavigate();
  return (
    <div className="org-registerbox">
      <h2>Register</h2>
      <div className="form">
      <input 
          type="text"
          onChange={ (e) => dispatch({
            type: RegisterActionType.UPDATE_REGISTER_FORM,
            username: e.currentTarget.value,
            password: state.password
          }) } />
        <input 
          type="password"
          onChange={ (e) => dispatch({
            type: RegisterActionType.UPDATE_REGISTER_FORM,
            username: state.username,
            password: e.currentTarget.value
          }) } />
        <button 
          children="Register"
          onClick={ () => {
            dispatch({ type: RegisterActionType.REGISTER_IN_PROGRESS });
            axios.post('http://localhost:3500/Register', {
              UserName: state.username,
              Password: state.password
            })
              .then(response => {
                dispatch({ type: RegisterActionType.REGISTER_SUCCESS });
                navigate('/login');
              })
              .catch(err => dispatch({ 
                type: RegisterActionType.REGISTER_ERROR 
              }))
          }} />
      </div>
      <Link to="/login">Already have an account? Sign In</Link>
    </div>
  );
}