import { LoginAction, LoginActionType } from "./LoginActions";
import { LoginState } from "./LoginState";

export default (previousState: LoginState, action: LoginAction): LoginState => {
  switch (action.type) {
    case LoginActionType.UPDATE_LOGIN_FORM:
      return {
        ...previousState,
        username: action.username,
        password: action.password
      };

    case LoginActionType.LOGIN_IN_PROGRESS:
      return previousState;

    case LoginActionType.LOGIN_SUCCESS:
      return previousState;

    case LoginActionType.LOGIN_ERROR:
      return previousState;
  }
}