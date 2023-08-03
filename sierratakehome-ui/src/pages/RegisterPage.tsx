import { useReducer } from "react";
import RegisterTemplate from "../templates/RegisterTemplate/RegisterTemplate";
import LoginReducer from "../reducers/LoginReducer/LoginReducer";
import { LoginInitialState } from "../reducers/LoginReducer/LoginState";

export default () => {
  const [state, dispatch] = useReducer(LoginReducer, LoginInitialState);
  return (
    <RegisterTemplate
      state={ state }
      dispatch={ dispatch } />
  );
}