import { useReducer } from "react";
import LoginTemplate from "../templates/LoginTemplate/LoginTemplate";
import LoginReducer from "../reducers/LoginReducer/LoginReducer";
import { LoginInitialState } from "../reducers/LoginReducer/LoginState";

export default () => {
  const [state, dispatch] = useReducer(LoginReducer, LoginInitialState);
  return (
    <LoginTemplate
      state={ state }
      dispatch={ dispatch } />
  );
};