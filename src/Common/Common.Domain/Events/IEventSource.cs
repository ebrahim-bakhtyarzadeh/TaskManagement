namespace Common.Domain.Events
{
	 public interface IEventSource
	 {
		  Task SaveEvent<TEvent>(string aggregateName, string streamId, CancellationToken cancellationToken, IEnumerable<TEvent> events, int? expectedVersion = null) where TEvent : IDomainEvent;


		
	 }
}
