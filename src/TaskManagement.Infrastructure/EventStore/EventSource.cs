using Common.Domain.Events;
using EventStore.Client;
using Newtonsoft.Json;
using System;
using System.Text;

namespace TaskManagement.Infrastructure.EventStore
{
	 public class EventSource : IEventSource
	 {
		  private readonly EventStoreClient _eventStoreConnection;

		  public EventSource(EventStoreClient eventStoreConnection)
		  {
			   _eventStoreConnection = eventStoreConnection;
		  }
		  // این متد برای ارسال ایونت ها به دیتابیس ایونت استور هست
		  // این متد توسط یک برنامه نویس دیگر نوشته شده و از طریق گیتهاب به این کد رسیدم و هوش مصنوعی در ان دستی نداشته
	



		  private static byte[] Serialize(object obj) => Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));

		  public async Task SaveEvent<TEvent>(string aggregateName, string streamId, CancellationToken cancellationToken, IEnumerable<TEvent> events, int? expectedVersion = null) where TEvent : IDomainEvent
		  {
			   var eventList = events?.ToList() ?? new List<TEvent>();
			   if (!eventList.Any()) return;

			   var changes = eventList
				   .Select(@event => new EventData(
				eventId: Uuid.NewUuid(),
					   @event.GetType().Name,
					   Serialize(@event),
					 metadata: Serialize(new EventMetaData
					 {
						  ClrType = @event.GetType().AssemblyQualifiedName
					 })
				   )).ToArray();

			   var streamName = $"{aggregateName}-{streamId}";

			   if (expectedVersion.HasValue)
			   {
					await _eventStoreConnection.AppendToStreamAsync(
						streamName,
					  StreamState.Any,

						changes

					);
			   }
			   else
			   {
					await _eventStoreConnection.AppendToStreamAsync(
						streamName,
						StreamState.Any,
						changes
					);
			   }
		  }
	 }
	 internal class EventMetaData
	 {
		  public string ClrType { get; set; }
	 }
}
