package vn.elca.codebase.common.dto;

/**
 * Model of a error body to be sent to client in case error happens in the backend. Should includes at least a
 * correlation ID and the relevant error message.
 */
public interface ServerErrorResponse {
    ServerErrorType getErrorType();
}