using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoApp.Models;

[Table("todo")]
public class ToDo
{

    // The category ID of the todo item.
    [Key]
    [Column("todo_id")]
    public int Id { get; set; }

    // The name of the todo item.
    [Column("name")]
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    // The date and time when the todo item was created.
    [Column("created_date_time")]
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;

}